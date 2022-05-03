using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class Item:ItemBase
    {
        public Item()
        {

        }
        public Item(int id,string nombre,decimal precio,int cantidad):base(id,nombre,precio,cantidad)
        {
        }
        
        public override string Imprimir()
        {
            string ticket =$"{_Id} {_Nombre} su precio es: {_Precio} cantidad: {_Cantidad} Subtotal: {SubTotal()}" +
                $"\nTotal: {Total()}";
            return ticket;
        }
    }
}
