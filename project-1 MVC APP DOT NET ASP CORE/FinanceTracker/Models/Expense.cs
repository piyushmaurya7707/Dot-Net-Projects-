using System.ComponentModel.DataAnnotations;// if you use data annotation from this class 

namespace FinanceApp.Models
{
    
    public class Expense
    {
        public int Id {get; set; }
        [Required] //data notation 

        public string Description {get; set;} = null!;// why we want to set thing as null! in string 
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount need to be higher than zero")]
        public double Amount {get; set;}//Semicolon after method or accessor block is not validCS1597

        public string category { get; set; } = null!;
        [Required]

        public DateTime Date { get; set; } = DateTime.Now;
        
    }
}