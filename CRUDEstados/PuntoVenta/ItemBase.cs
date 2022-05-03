using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public abstract class ItemBase
    {
        public int _Id { get; set; }
        public string _Nombre { get; set; }
        public decimal _Precio { get; set; }
        public int _Cantidad { get; set; }
        public ItemBase()
        {

        }
        public ItemBase(int id,string nombre, decimal precio,int cantidad)
        {
            this._Id = id;
            this._Nombre = nombre;
            this._Precio = precio;
            this._Cantidad = cantidad;
        }
        public virtual decimal SubTotal()
        {
            decimal subTotal = _Precio*_Cantidad;
            return subTotal;
        }
        public virtual decimal Total()
        {
            decimal total =+_Precio*_Cantidad;
            return total;
        }
        public abstract string Imprimir();
    }
}
