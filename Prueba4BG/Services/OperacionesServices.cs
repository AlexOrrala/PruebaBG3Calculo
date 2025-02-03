using Prueba4BG.Models;

using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace Prueba4BG.Services
{
    public class OperacionesServices
    {
        public ApplicationDBContext _context;

        
        public OperacionesServices(ApplicationDBContext context) {
            _context = context;
        }

        public async Task<Operaciones> Operar(Operaciones body)
        {
            validarOperaciones(body.operacion, body.valor1, body.valor2);

            consultarSOAP(body);
            // consumo la api para sumar
            //Task<Operaciones> Result = Api(SOAP(body.operacion)) 


            await _context.Operaciones.AddAsync(body);
            await _context.SaveChangesAsync();

            return body;

        }

        public async void consultarSOAP(Operaciones body) {
            CalculatorSoapClient cliente = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);


            AddRequest addRequest = new AddRequest(body.valor1, body.valor2);
            cliente.Add(addRequest);
            SubtractRequest subtract = new SubtractRequest(body.valor1,body.valor2);

            Console.WriteLine(subtract.ToString());
            cliente.AddAsync(addRequest);
            
            int resultado2 = 0;
            AddResponse resultado = new AddResponse(resultado2);
            
            


            Console.WriteLine(resultado2);
            Console.WriteLine(resultado.ToString());


        }


        private void divisionZero(int valor1, int valor2)
        {
            if (valor2 ==0)
            {
                throw new DivideByZeroException("No se puede dividir para 0");
            }
        }

        private void validarOperaciones(string operacion, int valor1, int valor2)
        {
            if (!(operacion.Equals("sumar") ||
                operacion.Equals("restar") || 
                operacion.Equals("multiplicar") || 
                operacion.Equals("dividir")))
            {
                throw new ArgumentException("""operacion solo puede ser \"sumar\", \"restar\", \"multiplicar\", \"dividir\""");
            }
            if (operacion.Equals("dividir"))
            {
                divisionZero(valor1, valor2);
            }
        }
    }
}
