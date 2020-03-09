//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quitanda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Pedido = new HashSet<Pedido>();
        }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe o seu CPF")]
        public string CPF { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o seu Nome")]
        public string Nome { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "Informe o seu Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "N�mero")]
        [Required(ErrorMessage = "Informe o seu n�mero do endere�o")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        [Required(ErrorMessage = "Informe o complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Informe o bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Informe a sua Cidade")]
        public string Cidade { get; set; }

        public string CEP { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Informe o seu Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Email")]       
        public string Email_login { get; set; }

        [Display(Name = "Senha")]
        public string Senha_login { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
