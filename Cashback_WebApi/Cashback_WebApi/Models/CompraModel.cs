using Cashback_WebApi.Biblioteca.Constantes;
using Cashback_WebApi.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class CompraModel : Base
    {
        internal readonly string CpfRevendedorStatusAprovado;

        public CompraModel()
        {
            var builder = new BuilderHelper();
            CpfRevendedorStatusAprovado = builder._configuration["CpfRevendedorStatusAprovado"];
        }

        private double valor;
        private string cpfRevendedor;

        [Required]
        public string CodigoCompra { get; set; }

        [Required]
        public double Valor
        {
            get { return valor; }
            set
            {
                cashback =  CalcularCashBack(value);
                valor = value;
            }
        }

        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public string Status { get; set; }

        [MaxLength(11)]
        public string CpfRevendedor
        {
            get {return cpfRevendedor; }
            set
            {
                var cpfNumeros = value.Replace(".", string.Empty).Replace("-", string.Empty);
                Status = ComporStatus(cpfNumeros);
                cpfRevendedor = cpfNumeros;
            }
        }

        [ForeignKey("Revendedora")]
        public string RevendedoraId { get; set; }
        public RevendedoraModel Revendedora { get; set; }

        private double cashback;
        public double Cashback
        {
            get { return cashback; }
            set { cashback = CalcularCashBack(value); }
        }

        private double CalcularCashBack(double valor)
        {
            if (valor < 1000)
                return valor * 0.1;
            else if (valor >= 1000 && valor <= 1500)
                return valor * 0.15;
            else
                return valor * 0.2;
        }

        private string ComporStatus(string cpfRevendedor)
        {
            if (cpfRevendedor == CpfRevendedorStatusAprovado)
                return StatusCompraConstante.Aprovado;
            else
                return StatusCompraConstante.EmValidacao;
        }
    }
}
