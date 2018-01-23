using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    // clientes 
    public class Customer
    {
        public int Id { get; set; }

        //campo obligatorio , tamaño minimo aceptado 10 caracteres

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required]
        public string Ciudad { get; set; }

    }
}