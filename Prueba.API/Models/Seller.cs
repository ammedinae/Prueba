using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prueba.API.Models
{
    public class Seller
    {
        public static List<SellerResponse> SellerConsulta()
        {
            try
            {
                List<SellerResponse> lstSeller = new List<SellerResponse>();

                using (dboPruebaEntities db = new dboPruebaEntities())
                {
                    lstSeller = (from s in db.Seller
                                 select new SellerResponse
                                 {
                                     Code = s.Code,
                                     Names = s.Names,
                                     Last_Name = s.Last_Name,
                                     Document = s.Document,
                                     City_Id = s.City_Id,
                                     City_Description = s.City.Description
                                 }).ToList();
                }

                return lstSeller;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SellerResponse SellerConsultaId(long id)
        {
            try
            {
                SellerResponse seller = new SellerResponse();

                using (dboPruebaEntities db = new dboPruebaEntities())
                {
                    seller = (from s in db.Seller
                              where s.Code == id
                              select new SellerResponse
                              {
                                  Code = s.Code,
                                  Names = s.Names,
                                  Last_Name = s.Last_Name,
                                  Document = s.Document,
                                  City_Id = s.City_Id,
                                  City_Description = s.City.Description
                              }).FirstOrDefault();
                }

                return seller;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool SellerCrear(SellerDto sellerDto)
        {
            try
            {
                bool valida = false;
                Prueba.Models.Seller seller = new Prueba.Models.Seller();

                using (dboPruebaEntities db = new dboPruebaEntities())
                {
                    var sellerExiste = db.Seller.Where(x => x.Document == sellerDto.Document).FirstOrDefault();

                    if (sellerExiste != null) seller = sellerExiste;

                    seller.Names = sellerDto.Names;
                    seller.Last_Name = sellerDto.Last_Name;
                    seller.Document = sellerDto.Document;
                    seller.City_Id = sellerDto.City_Id;

                    if (sellerExiste == null)
                    {
                        db.Seller.Add(seller);
                    }

                    db.SaveChanges();

                    if (seller.Code > 0)
                    {
                        valida = true;
                    }
                }

                return valida;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SellerEliminar(long id)
        {
            try
            {
                bool valida = false;

                using (dboPruebaEntities db = new dboPruebaEntities())
                {
                    var sellerExiste = db.Seller.Where(x => x.Code == id).FirstOrDefault();

                    if (sellerExiste != null)
                    {
                        db.Seller.Remove(sellerExiste);
                        db.SaveChanges();
                    }

                    valida = true;
                }

                return valida;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}