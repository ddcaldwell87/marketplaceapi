using Marketplace.Data;
using Marketplace.Models.Retailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Services
{
     public class RetailerService
    {
        private readonly int _RetailerId;
        private readonly int _customerID;
        private readonly Guid _userID;

        public RetailerService(Guid userId)
        {
            _userID = userId;
        }

        public RetailerDetails GetRetailerbyId(int RetailerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Retailers
                        .Single(e => e.RetailerId == RetailerID && e.OwnerId == _userID);
                return
                    new RetailerDetails
                    {
                        RetailerId = entity.RetailerId,
                        RetailerName = entity.RetailerName,
                        RetailerEin = entity.RetailerEin,
                        RetailerAddress = entity.RetailerAddress,
                        RetailerEmail = entity.RetailerEmail,
                        RetailerPhone = entity.RetailerPhone,
                    };
            }
        }
        public bool CreateRetailer(RetailerCreate model)
        {
            var entity =
               new Retailer
               {
                   RetailerId = _RetailerId,
                   RetailerName = model.RetailerName,
                   RetailerEin = model.RetailerEin,
                   RetailerAddress = model.RetailerAddress,
                   RetailerEmail = model.RetailerEmail,
                   RetailerPhone = model.RetailerPhone
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Retailers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<RetailerListItem> GetAllRetailers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Retailer =
                    ctx
                        .Retailers
                        .Select(
                            e => new RetailerListItem()
                            {

                                RetailerId = e.RetailerId,
                                RetailerName = e.RetailerName,
                                RetailerEin = e.RetailerEin,
                                RetailerAddress = e.RetailerAddress,
                                RetailerEmail = e.RetailerEmail,
                                RetailerPhone = e.RetailerPhone,

                            });

                return Retailer.ToList();
            }
        }
        public bool DeleteRetailer(int RetailerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Retailers
                        .Single(e => e.RetailerId == RetailerID);

                ctx.Retailers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateRetailer(Retailer model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Retailers
                        .Single(e => e.RetailerId == model.RetailerId && e.OwnerId == _userID);

                entity.RetailerName = model.RetailerName;
                entity.RetailerEin = model.RetailerEin;
                entity.RetailerAddress = model.RetailerAddress;
                entity.RetailerEmail = model.RetailerEmail;
                entity.RetailerPhone = model.RetailerPhone;

                return ctx.SaveChanges() == 1;
            }
        }
        //public ICollection<RetailerListItem> GetProductbyRetailerName(string RetailerName)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var Retailers =
        //            ctx
        //                .Retailers
        //                .Where(c => c.RetailerName == RetailerName)
        //                .Select(
        //                    e => new RetailerListItem()
        //                    {
        //                        RetailerId = e.RetailerId,
        //                        RetailerName = e.RetailerName,
        //                        RetailerEin = e.RetailerEin,
        //                        RetailerAddress = e.RetailerAddress,
        //                        RetailerEmail = e.RetailerEmail,
        //                        RetailerPhone = e.RetailerPhone,

        //                    });

        //        var retailerLists = Retailers.ToList();

        //        foreach (var Retailer in retailerLists)
        //        {
        //            Retailer.RetailerName = GetProductbyRetailerName(Retailer.RetailerId);
        //        }

        //        return retailerLists;
        //    }
    }
}
