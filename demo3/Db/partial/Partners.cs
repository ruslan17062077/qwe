using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demo3.Db
{
    public partial class Partners
    {
        public decimal Sum
        {
            get
            {
                decimal summ = 0;
                foreach(var item in App.db.Partner_product.Where(x=>x.id_partnera == id))
                {
                    summ += decimal.Parse(item.count.ToString()) * item.Product.min_chena ?? 0;
                }
                return summ;
            }
        }
    }
}
