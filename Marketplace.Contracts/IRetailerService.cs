using Marketplace.Models.Retailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Contracts
{
    public interface IRetailerService
    {
        RetailerDetails GetRetailerbyId(int RetailerID);
        bool CreateRetailer(RetailerCreate model);
        ICollection<RetailerListItem> GetAllRetailers();
        bool DeleteRetailer(int RetailerID);
        bool UpdateRetailer(RetailerEdit model);
    }
}
