
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;


namespace Chess.Client.ViewModels
{
    public class SetUpViewModel : ISetUpViewModel
    {
       
        public bool IsMyColorWhite { get; set; }
        [Required]
        public string OpponentId { get; set; }
        public bool IsTimerSet { get; set; }
        [Required]
        public string TimeOut { get; set; }
        [Required]
        public string IncrementTimerBy { get; set; }
        
       
        
        
        

        

        

    }
}