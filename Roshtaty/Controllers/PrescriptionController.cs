using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Repositories;
using Roshtaty.Core.Specifications;
using Roshtaty.DTOS;
using Roshtaty.Helpers;
using Roshtaty.Repository.Data;

namespace Roshtaty.Controllers
{
  
    public class PrescriptionController : ApiBaseController
    {
        private readonly RoshtatyContext _PrescriptionRepo;
        private readonly IMapper _mapper;
        private readonly OTPService _otpService;
        private readonly ISmsService _smsService;

        public PrescriptionController(RoshtatyContext  roshtatyContext, IMapper mapper, OTPService otpService, ISmsService smsService)
        {
            _PrescriptionRepo = roshtatyContext;
            _mapper = mapper;
            _otpService = otpService;
            _smsService = smsService;
        }


        [HttpPost("add-prescription")]
        public async Task<ActionResult> AddPrescription(
    [FromQuery] string patientName,
    [FromQuery] string activeIngredientName,
    [FromQuery] string dose,
    [FromQuery] string form,
    [FromQuery] decimal strength,
    [FromQuery] string strengthUnit,
    [FromQuery] string phoneNumber,
    [FromQuery] string prescriptionName,
            [FromQuery] string dispensedmedication)
        {
            // التحقق من وجود الروشتة بنفس التفاصيل
            var existingPrescription = await _PrescriptionRepo.Prescriptions
                .FirstOrDefaultAsync(p =>
                    p.PatientName == patientName &&
                    p.Dose == dose &&
                    p.Form == form &&
                    p.PhoneNumber == phoneNumber &&
                    p.Prescription_Name == prescriptionName &&
                    p.Dispensedmedication == dispensedmedication);


            if (existingPrescription != null)
            {
                return BadRequest("Prescription with the same details already exists.");
            }

            // التحقق من المادة الفعالة بناءً على الاسم والقوة ووحدة القوة
            var activeIngredient = await _PrescriptionRepo.Active_Ingredients
                .FirstOrDefaultAsync(a =>
                    a.ActiveIngredientName == activeIngredientName &&
                    a.Strength == strength &&
                    a.StrengthUnit == strengthUnit);

            if (activeIngredient == null)
            {
                return NotFound("Active ingredient with the specified strength and unit not found.");
            }

            // إضافة وصفة جديدة
            var prescription = new Prescription
            {
                Prescription_Name = prescriptionName,
                Dose = dose,
                Form = form,
                PatientName = patientName,
                PhoneNumber = phoneNumber,
                PrescriptionDate = DateTime.Now,
                Active_IngredientId = activeIngredient.Id, // التأكد من أن Active_IngredientId هنا هو int
                Dispensedmedication = dispensedmedication // يمكن تعديل هذا الحقل لاحقًا بعد صرف الدواء
            };

            // إضافة الوصفة إلى قاعدة البيانات
            _PrescriptionRepo.Prescriptions.Add(prescription);
            await _PrescriptionRepo.SaveChangesAsync();

            return Ok(new { message = "Prescription added successfully!" });
        }












        [HttpGet("SendOTP")]
        public async Task<IActionResult> SendOTP([FromQuery] string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest("Phone number is required.");
            }

            // توليد OTP عشوائي
            var otp = _otpService.GenerateOTP();
            _otpService.StoreOTP(phoneNumber, otp);  // تخزين الـ OTP في الذاكرة

            // إرسال OTP عبر الـ SMS باستخدام Twilio
            bool smsSent = await _smsService.SendSMS(phoneNumber, $"Your OTP is: {otp}");

            if (!smsSent)
            {
                return StatusCode(500, "Failed to send OTP.");
            }

            return Ok("OTP sent successfully.");
        }

        




        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP([FromQuery] string phoneNumber, [FromQuery] string otp)
        {
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(otp))
            {
                return BadRequest("Phone number and OTP are required.");
            }

            // التحقق من الـ OTP
            bool isValid = _otpService.ValidateOTP(phoneNumber, otp);

            if (!isValid)
            {
                return Unauthorized("Invalid or expired OTP.");
            }

            // إذا كان الـ OTP صحيحًا، استرجاع الروشتات
            var prescriptions = await _PrescriptionRepo.Prescriptions
                .Where(p => p.PhoneNumber == phoneNumber)
                .Include(p => p.Active_Ingredient)  // ضم بيانات المادة الفعالة
                .ToListAsync();  // استخدم ToListAsync بدلاً من ToList

            if (prescriptions == null || !prescriptions.Any())
            {
                return NotFound($"No prescriptions found for phone number: {phoneNumber}");
            }

            var result = prescriptions.Select(p => new PrescriptionToReturnDTO
            {
                Prescription_Name = p.Prescription_Name,
                PatientName = p.PatientName,
                ActiveIngridient_Name = p.Active_Ingredient != null ? p.Active_Ingredient.ActiveIngredientName : null, // جلب اسم المادة الفعالة
                Dose = p.Dose,
                Form = p.Form,
                Strength = p.Active_Ingredient != null ? p.Active_Ingredient.Strength : 0, // جلب قوة المادة الفعالة
                StrengthUnit = p.Active_Ingredient != null ? p.Active_Ingredient.StrengthUnit : null, // جلب وحدة المادة الفعالة
                PhoneNumber = p.PhoneNumber,
                PrescriptionDateRaw = p.PrescriptionDate,
                Dispensedmedication = p.Dispensedmedication

            }).ToList();

            return Ok(result);
        }



        //without
        [HttpPost("GetPrescriptionswithout")]
        public async Task<IActionResult> GetPrescriptions([FromQuery] string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest("Phone number is required.");
            }

            // استرجاع الوصفات بناءً على رقم الهاتف
            var prescriptions = await _PrescriptionRepo.Prescriptions
                .Where(p => p.PhoneNumber == phoneNumber)
                .Include(p => p.Active_Ingredient)  // ضم بيانات المادة الفعالة
                .ToListAsync();

            if (prescriptions == null || !prescriptions.Any())
            {
                return NotFound($"No prescriptions found for phone number: {phoneNumber}");
            }

            var result = prescriptions.Select(p => new PrescriptionToReturnDTO
            {
                Prescription_Name = p.Prescription_Name,
                PatientName = p.PatientName,
                ActiveIngridient_Name = p.Active_Ingredient != null ? p.Active_Ingredient.ActiveIngredientName : null, // جلب اسم المادة الفعالة
                Dose = p.Dose,
                Form = p.Form,
                Strength = p.Active_Ingredient != null ? p.Active_Ingredient.Strength : 0, // جلب قوة المادة الفعالة
                StrengthUnit = p.Active_Ingredient != null ? p.Active_Ingredient.StrengthUnit : null, // جلب وحدة المادة الفعالة
                PhoneNumber = p.PhoneNumber,
                PrescriptionDateRaw = p.PrescriptionDate,
                Dispensedmedication = p.Dispensedmedication

            }).ToList();

            return Ok(result);
        }


        //    [HttpPost("AddDispensedMedication")]
        //    public async Task<IActionResult> AddDispensedMedication(
        //[FromQuery] int prescriptionId,  // ID الوصفة التي سيتم إضافة الدواء المصروف لها
        //[FromQuery] string tradeName)   // اسم الدواء التجاري المصروف
        //    {
        //        if (string.IsNullOrEmpty(tradeName))
        //        {
        //            return BadRequest("Trade name is required.");
        //        }

        //        // استرجاع الوصفة بناءً على الـ ID
        //        var prescription = await _PrescriptionRepo.Prescriptions
        //            .FirstOrDefaultAsync(p => p.Id == prescriptionId);

        //        if (prescription == null)
        //        {
        //            return NotFound("Prescription not found.");
        //        }

        //        // التحقق مما إذا كان الدواء التجاري موجودًا في قائمة الأدوية التجارية للمادة الفعالة المرتبطة بالوصفة
        //        var activeIngredient = await _PrescriptionRepo.Active_Ingredients
        //            .FirstOrDefaultAsync(a => a.Id == prescription.Active_IngredientId);

        //        if (activeIngredient == null)
        //        {
        //            return NotFound("Active ingredient not found.");
        //        }

        //        // استرجاع الأدوية التجارية المرتبطة بالمادة الفعالة
        //        var validTradeNames = await _PrescriptionRepo.tradeNames
        //            .Where(t => t.Active_IngredientId == activeIngredient.Id)
        //            .Select(t => t.TradeName)
        //            .ToListAsync();

        //        // التحقق مما إذا كان الدواء التجاري المختار موجودًا في القائمة
        //        if (!validTradeNames.Contains(tradeName))
        //        {
        //            return BadRequest("The selected trade name is not valid for the active ingredient.");
        //        }

        //        // إضافة الدواء التجاري إلى الوصفة
        //        prescription.Dispensedmedication = tradeName;

        //        // حفظ التحديث في قاعدة البيانات
        //        _PrescriptionRepo.Prescriptions.Update(prescription);
        //        await _PrescriptionRepo.SaveChangesAsync();

        //        return Ok(new { message = "Dispensed medication added successfully!" });
        //    }


        //    [HttpPost("AddDispensedMedicationn")]
        //    public async Task<IActionResult> AddDispensedMedication(
        //[FromQuery] int prescriptionId,  // ID الوصفة التي سيتم إضافة الدواء المصروف لها
        //[FromQuery] string tradeName)   // اسم الدواء التجاري المصروف
        //    {
        //        // التحقق من وجود اسم الدواء التجاري
        //        if (string.IsNullOrEmpty(tradeName))
        //        {
        //            return BadRequest("Trade name is required.");
        //        }

        //        // استرجاع الوصفة بناءً على ID الوصفة
        //        var prescription = await _PrescriptionRepo.Prescriptions
        //            .FirstOrDefaultAsync(p => p.Id == prescriptionId);

        //        // التحقق من أن الوصفة موجودة
        //        if (prescription == null)
        //        {
        //            return NotFound("Prescription not found.");
        //        }

        //        // استرجاع المادة الفعالة المرتبطة بالوصفة
        //        var activeIngredient = await _PrescriptionRepo.Active_Ingredients
        //            .FirstOrDefaultAsync(a => a.Id == prescription.Active_IngredientId);

        //        // التحقق من أن المادة الفعالة موجودة
        //        if (activeIngredient == null)
        //        {
        //            return NotFound("Active ingredient not found.");
        //        }

        //        // استرجاع الأدوية التجارية المرتبطة بالمادة الفعالة
        //        var validTradeNames = await _PrescriptionRepo.tradeNames
        //            .Where(t => t.Active_IngredientId == activeIngredient.Id)
        //            .Select(t => t.TradeName)
        //            .ToListAsync();

        //        // التحقق مما إذا كان الدواء التجاري المختار موجودًا في القائمة المرتبطة بالمادة الفعالة
        //        if (!validTradeNames.Contains(tradeName))
        //        {
        //            return BadRequest("The selected trade name is not valid for the active ingredient.");
        //        }

        //        // إضافة الدواء التجاري إلى الوصفة
        //        prescription.Dispensedmedication = tradeName;

        //        // حفظ التحديث في قاعدة البيانات
        //        _PrescriptionRepo.Prescriptions.Update(prescription);
        //        await _PrescriptionRepo.SaveChangesAsync();

        //        // إرسال الرد بنجاح
        //        return Ok(new { message = "Dispensed medication added successfully!" });
        //    }






        //    [HttpPost("AddDispensedMedication")]
        //    public async Task<IActionResult> AddDispensedMedication(
        //[FromQuery] string prescriptionName,  // اسم الروشتة التي سيتم إضافة الدواء المصروف لها
        //[FromQuery] string tradeName)         // اسم الدواء التجاري المصروف
        //    {
        //        if (string.IsNullOrEmpty(tradeName))
        //        {
        //            return BadRequest("Trade name is required.");
        //        }

        //        // استرجاع الوصفة بناءً على اسم الروشتة
        //        var prescription = await _PrescriptionRepo.Prescriptions
        //            .FirstOrDefaultAsync(p => p.Prescription_Name == prescriptionName);

        //        // التحقق من وجود الوصفة
        //        if (prescription == null)
        //        {
        //            return NotFound("Prescription not found.");
        //        }

        //        // استرجاع المادة الفعالة المرتبطة بالوصفة
        //        var activeIngredient = await _PrescriptionRepo.Active_Ingredients
        //            .FirstOrDefaultAsync(a => a.Id == prescription.Active_IngredientId);

        //        if (activeIngredient == null)
        //        {
        //            return NotFound("Active ingredient not found.");
        //        }

        //        // استرجاع قائمة الأدوية التجارية المرتبطة بالمادة الفعالة
        //        var validTradeNames = await _PrescriptionRepo.tradeNames
        //            .Where(t => t.Active_IngredientId == activeIngredient.Id)
        //            .Select(t => t.TradeName)
        //            .ToListAsync();

        //        // التحقق مما إذا كان الدواء التجاري المختار موجودًا في القائمة
        //        if (!validTradeNames.Contains(tradeName))
        //        {
        //            return BadRequest("The selected trade name is not valid for the active ingredient.");
        //        }

        //        // إضافة الدواء التجاري إلى الوصفة
        //        prescription.Dispensedmedication = tradeName;

        //        // حفظ التحديث في قاعدة البيانات
        //        _PrescriptionRepo.Prescriptions.Update(prescription);
        //        await _PrescriptionRepo.SaveChangesAsync();

        //        return Ok(new { message = "Dispensed medication added successfully!" });
        //    }



        [HttpGet("GetTradeNamesForPrescription")]
        public async Task<IActionResult> GetTradeNamesForPrescription(
     [FromQuery] string prescriptionName, 
     [FromQuery] string phoneNumber,      
     [FromQuery] string? sortBy)         
        {
            if (string.IsNullOrEmpty(prescriptionName) || string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest("Prescription name and phone number are required.");
            }

            var prescription = await _PrescriptionRepo.Prescriptions
                .Include(p => p.Active_Ingredient)  
                .FirstOrDefaultAsync(p => p.Prescription_Name == prescriptionName && p.PhoneNumber == phoneNumber);

            if (prescription == null)
            {
                return NotFound("Prescription not found.");
            }

            var activeIngredient = prescription.Active_Ingredient;
            if (activeIngredient == null)
            {
                return NotFound("Active ingredient not found in the prescription.");
            }

            var tradesQuery = _PrescriptionRepo.tradeNames
                .Where(t => t.Active_IngredientId == activeIngredient.Id)
                .Select(t => new
                {
                    t.TradeName,          
                    t.PublicPrice,        
                    t.Dose,               
                    t.PharmaceuticalForm  
                });

            if (!string.IsNullOrEmpty(sortBy))
            {
                tradesQuery = sortBy.ToLower() switch
                {
                    "priceasc" => tradesQuery.OrderBy(t => t.PublicPrice),             
                    "pricedesc" => tradesQuery.OrderByDescending(t => t.PublicPrice),  
                    "tradenameaz" => tradesQuery.OrderBy(t => t.TradeName),            
                    _ => tradesQuery.OrderBy(t => t.TradeName)                         
                };
            }
            else
            {
                tradesQuery = tradesQuery.OrderBy(t => t.TradeName);    
            }

            var trades = await tradesQuery.ToListAsync();

            if (!trades.Any())
            {
                return NotFound("No trades found for the given active ingredient.");
            }

            return Ok(trades);
        }


        //    [HttpGet("GetTradeNamesForPrescription")]
        //    public async Task<IActionResult> GetTradeNamesForPrescription(
        //[FromQuery] string prescriptionName,  // اسم الروشتة
        //[FromQuery] string phoneNumber)       // رقم التليفون
        //    {
        //        if (string.IsNullOrEmpty(prescriptionName) || string.IsNullOrEmpty(phoneNumber))
        //        {
        //            return BadRequest("Prescription name and phone number are required.");
        //        }

        //        // استرجاع الوصفة بناءً على اسم الروشتة ورقم التليفون
        //        var prescription = await _PrescriptionRepo.Prescriptions
        //            .Include(p => p.Active_Ingredient)  // ضم بيانات المادة الفعالة
        //            .FirstOrDefaultAsync(p => p.Prescription_Name == prescriptionName && p.PhoneNumber == phoneNumber);

        //        // التحقق من وجود الوصفة
        //        if (prescription == null)
        //        {
        //            return NotFound("Prescription not found.");
        //        }

        //        // استرجاع المادة الفعالة المرتبطة بالوصفة
        //        var activeIngredient = prescription.Active_Ingredient;
        //        if (activeIngredient == null)
        //        {
        //            return NotFound("Active ingredient not found in the prescription.");
        //        }

        //        // استرجاع الأدوية التجارية المرتبطة بالمادة الفعالة مع التفاصيل
        //        var tradeNames = await _PrescriptionRepo.tradeNames
        //            .Where(t => t.Active_IngredientId == activeIngredient.Id)
        //            .Select(t => new
        //            {
        //                t.TradeName,           // اسم الدواء التجاري
        //                t.PublicPrice,         // السعر
        //                t.Dose,                // الجرعة
        //                t.PharmaceuticalForm   // الفورم
        //            })
        //            .ToListAsync();

        //        // التحقق إذا كان هناك أدوية تجارية مرتبطة
        //        if (!tradeNames.Any())
        //        {
        //            return NotFound("No trade names found for the active ingredient.");
        //        }

        //        // إرجاع قائمة الأدوية التجارية مع تفاصيلها
        //        return Ok(new { TradeNames = tradeNames });
        //    }


        //ادد منها

        [HttpPost("AddDispensedMedication")]
        public async Task<IActionResult> AddDispensedMedication(
    [FromQuery] string prescriptionName,  // اسم الروشتة
    [FromQuery] string phoneNumber,       // رقم التليفون
    [FromQuery] string tradeName)        // اسم الدواء التجاري
        {
            if (string.IsNullOrEmpty(tradeName))
            {
                return BadRequest("Trade name is required.");
            }

            // استرجاع الوصفة بناءً على اسم الروشتة ورقم التليفون
            var prescription = await _PrescriptionRepo.Prescriptions
                .FirstOrDefaultAsync(p => p.Prescription_Name == prescriptionName && p.PhoneNumber == phoneNumber);

            if (prescription == null)
            {
                return NotFound("Prescription not found.");
            }

            // التحقق من أن المادة الفعالة المرتبطة بالوصفة تحتوي على هذا الدواء
            var activeIngredient = await _PrescriptionRepo.Active_Ingredients
                .FirstOrDefaultAsync(a => a.Id == prescription.Active_IngredientId);

            if (activeIngredient == null)
            {
                return NotFound("Active ingredient not found.");
            }

            // استرجاع الأدوية التجارية المرتبطة بالمادة الفعالة
            var validTradeNames = await _PrescriptionRepo.tradeNames
                .Where(t => t.Active_IngredientId == activeIngredient.Id)
                .Select(t => t.TradeName)
                .ToListAsync();

            // التحقق مما إذا كان الدواء التجاري المختار موجودًا في القائمة
            if (!validTradeNames.Contains(tradeName))
            {
                return BadRequest("The selected trade name is not valid for the active ingredient.");
            }

            // إضافة الدواء التجاري إلى الوصفة كدواء مصروف
            prescription.Dispensedmedication = tradeName;

            // حفظ التحديث في قاعدة البيانات
            _PrescriptionRepo.Prescriptions.Update(prescription);
            await _PrescriptionRepo.SaveChangesAsync();

            return Ok(new { message = "Dispensed medication added successfully!" });
        }


        //حلوه خليها


    //    [HttpPost("AddDispensedMedication")]
    //    public async Task<IActionResult> AddDispensedMedication(
    //[FromQuery] string prescriptionName,  // اسم الروشتة
    //[FromQuery] string phoneNumber,       // رقم التليفون
    //[FromQuery] string tradeName)         // اسم الدواء التجاري المصروف
    //    {
    //        if (string.IsNullOrEmpty(tradeName))
    //        {
    //            return BadRequest("Trade name is required.");
    //        }

    //        // استرجاع الوصفة بناءً على اسم الروشتة ورقم التليفون
    //        var prescription = await _PrescriptionRepo.Prescriptions
    //            .FirstOrDefaultAsync(p => p.Prescription_Name == prescriptionName && p.PhoneNumber == phoneNumber);

    //        // التحقق من وجود الوصفة
    //        if (prescription == null)
    //        {
    //            return NotFound("Prescription not found.");
    //        }

    //        // استرجاع المادة الفعالة المرتبطة بالوصفة
    //        var activeIngredient = await _PrescriptionRepo.Active_Ingredients
    //            .FirstOrDefaultAsync(a => a.Id == prescription.Active_IngredientId);

    //        if (activeIngredient == null)
    //        {
    //            return NotFound("Active ingredient not found.");
    //        }

    //        // استرجاع قائمة الأدوية التجارية المرتبطة بالمادة الفعالة
    //        var validTradeNames = await _PrescriptionRepo.tradeNames
    //            .Where(t => t.Active_IngredientId == activeIngredient.Id)
    //            .Select(t => t.TradeName)
    //            .ToListAsync();

    //        // التحقق مما إذا كان الدواء التجاري المختار موجودًا في القائمة
    //        if (!validTradeNames.Contains(tradeName))
    //        {
    //            return BadRequest("The selected trade name is not valid for the active ingredient.");
    //        }

    //        // إضافة الدواء التجاري إلى الوصفة
    //        prescription.Dispensedmedication = tradeName;

    //        // حفظ التحديث في قاعدة البيانات
    //        _PrescriptionRepo.Prescriptions.Update(prescription);
    //        await _PrescriptionRepo.SaveChangesAsync();

    //        return Ok(new { message = "Dispensed medication added successfully!" });
    //    }

    }

}

