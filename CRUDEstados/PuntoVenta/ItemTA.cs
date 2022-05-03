using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class ItemTA:ItemBase
    {
        public string Telefono { get; set; }
        public string Compañia { get; set; }
        public decimal Comision { get; set; }
        public ItemTA(int id, string nombre, decimal precio, int cantidad,string telefono,string compañia) : base(id, nombre, precio, cantidad)
        {
            Telefono = telefono;
            Compañia = compañia;
        }
        public ItemTA()
        {

        }
        public override decimal Total()
        {
            Comision = _Precio*.10m;
            decimal total = SubTotal()+Comision;
            return total;
        }
        public override string Imprimir()
        {
            string ticket = $"{_Id} {_Nombre} su precio es: {_Precio} cantidad: {_Cantidad} Subtotal: {SubTotal()}" +
                $"\nTelefono: {Telefono}\t Compañia: {Compañia}\t Comision: {Comision}\t" +
                $"\nTotal: {Total()}";
            return ticket;
        }
    }
}
