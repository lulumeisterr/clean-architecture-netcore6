using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudInMemory.Infrastructure.ExtensionsMethod
{

    public class Exemplo
    {
        public readonly double porcentual;

        public Exemplo(double porcentual)
        {
            this.porcentual = porcentual;
        }

        public void ValidarResultadoCalculo()
        {
            var result = this.CreateCalculo(11);
            Console.WriteLine("Resultado do cálculo: " + result);
        }
    }

    public static class RegraCalculo
    {
        public static double CreateCalculo(this Exemplo exemplo, double valorCalculo)
        {
            if (valorCalculo > exemplo.porcentual)
                return new CalcularEmprestimo().Calcular(valorCalculo);
            return new CalcularFinanciamento().Calcular(valorCalculo);
        }
    }
    public class CalcularEmprestimo : ICalculo
    {
        public double Calcular(double valorCalculo)
        {
            throw new NotImplementedException();
        }
    }

    public class CalcularFinanciamento : ICalculo
    {
        public double Calcular(double valorCalculo)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICalculo
    {
        double Calcular(double valorCalculo);
    }
}
