using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class ItemDescuento:ItemBase
    {
        public decimal _Descuento;
        readonly decimal _ImpDescuento=0.1m;
        public ItemDescuento()
        {

        }
        public ItemDescuento(int id, string nombre, decimal precio, int cantidad,decimal descuento) : base(id, nombre, precio, cantidad)
        {
            _Descuento = descuento;
        }

        public override decimal Total()
        {
            _Descuento = _Descuento * _ImpDescuento;
            decimal total = SubTotal() - _Descuento;
            return total;
        }
        public override string Imprimir()
        {
            string ticket = $"{_Id} {_Nombre} su precio es: {_Precio} cantidad: {_Cantidad} Subtotal: {SubTotal()}" +
                $"\nDescuento: {_Descuento}" +
                $"\nTotal: {Total()}";
            return ticket;
        }
    }
}
