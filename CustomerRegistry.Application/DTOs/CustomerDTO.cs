using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistry.Application.DTOs;

public class CustomerDTO
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "The name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The phone number is required")]
    [DataType(DataType.PhoneNumber)]
    [MinLength(10)]
    [MaxLength(17)]
    [DisplayName("Phone number")]
    public string? PhoneNumber { get; set; }

    [DataType(DataType.EmailAddress)]
    [DisplayName("Email")]
    public string? Email { get; set; }
        
    public bool IsActive { get; set; } = true;

    [Required(ErrorMessage = "The plan is required")]
    [AllowedValues("Monthly", "Bimonthly", "Quarterly", "Semiannual", "Annual")]
    [DisplayName("Plan")]
    public string? Plan { get; set; }

    [Required(ErrorMessage = "The Plan price is required")]
    [Column(TypeName = "decimal(5,2)")]
    [DisplayFormat(DataFormatString = "{C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Plan price")]
    public decimal PlanPrice { get; set; }

    [Required(ErrorMessage = "The last payment date is required")]
    [DisplayName("Last payment date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    [DataType(DataType.DateTime)]
    public DateTime LastPaymentDate { get; set; }

    [DisplayName("Next payment date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    [DataType(DataType.DateTime)]
    public DateTime NextPaymentDate { get; set; }

}
