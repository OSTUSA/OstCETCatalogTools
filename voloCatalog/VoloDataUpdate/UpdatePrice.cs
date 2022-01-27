using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.VoloDataUpdate
{
    internal class UpdatePrice
    {
        double productPriceChangeFactor = 0.1;
        double optionPriceChangeFactor = 0.1;

        bool productRoundDown = true;
        bool optionRoundDown = true;

        bool preview = false;

        public void run()
        {
            var dataHelper = new DataHelper();
            using var context = dataHelper.GetContext();

            using var transaction = context.Database.BeginTransaction();
            //List<long> modified = productPriceCodes(context);
            //optionPriceCodes(context, modified);
            differentApproach(context);
            if (!preview) {
                transaction.Commit();
            }
        }

        public void differentApproach(CetCatalogContext context)
        {

        }

        public List<long> productPriceCodes(CetCatalogContext context)
        {
            var products = from prod in context.DsProductTypes
                           select prod;

            List<PriceType> results = new List<PriceType>();
            List<long> alreadyModified = new List<long>();

            foreach (var p in products)
            {
                if (preview) Console.WriteLine(p.Code);
                var prices = from price in context.PriceTypeSeqPriceTypesRefs
                             where long.Parse(p.Prices) == price.OwnerKey
                             select price;

                foreach (var pr in prices)
                {
                    var finalPrices = from finalPrice in context.PriceTypes
                                      where finalPrice.Id == pr.ValueKey
                                      select finalPrice;


                    foreach (var thing in finalPrices)
                    {

                        if (alreadyModified.Contains(thing.Id))
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            continue;
                            
                        }
                        
                            if (thing.PricelistRef == "P1")
                        {
                            double res = calculatePriceChange(thing.Value ?? 0, true);
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef + " New Value: " + res);

                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P2";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);

                            var newPrice = new PriceType();
                            newPrice.Id = thing.Id;
                            newPrice.Code = thing.Code;
                            newPrice.PricelistRef = thing.PricelistRef;
                            newPrice.Value = res;

                           
                                results.Add((newPrice));

                        }
                        else if (thing.PricelistRef == "P2")
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P3";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);

                            //  context.PriceTypes.Update(oldPrice);
                            //  context.SaveChanges();

                        }
                        else if (thing.PricelistRef == "P3")
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P4";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);
                            //  context.PriceTypes.Update(oldPrice);
                            //  context.SaveChanges();

                        }
                        else if (thing.PricelistRef == "P4")
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P5";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);
                            //  context.PriceTypes.Update(oldPrice);
                            //  context.SaveChanges();

                        }
                        else if (thing.PricelistRef == "P5")
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            // context.PriceTypes.Remove(thing);
                            //  context.SaveChanges();
                            //do nothing
                        }
                    }
                }

                if (preview) Console.WriteLine("\t\nFINAL RESULTS: \n");
                foreach (var res in results)
                {
                    if (!alreadyModified.Contains(res.Id)) {
                        UpdatePriceType(context, res);
                        alreadyModified.Add(res.Id);
                    }
                    
                        if (preview) Console.WriteLine("\t\tValue: " + res.Value + "; " + res.PricelistRef);                    
                }

                results.Clear();
                if (preview) Console.WriteLine("******************************************************");
            }

            return alreadyModified;
        }

        public void optionPriceCodes(CetCatalogContext context, List<long> alreadyModified)
        {
            var options = from opt in context.Options
                          select opt;

            List<PriceType> results = new List<PriceType>();

            foreach (var o in options)
            {
                if (preview) Console.WriteLine(o.Code);
                var prices = from price in context.PriceTypeSeqPriceTypesRefs
                             where long.Parse(o.Prices) == price.OwnerKey
                             select price;

                foreach (var pr in prices)
                {
                    var finalPrices = from finalPrice in context.PriceTypes
                                      where finalPrice.Id == pr.ValueKey
                                      select finalPrice;


                    foreach (var thing in finalPrices)
                    {
                        if (alreadyModified.Contains(thing.Id))
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            continue;
                        }

                        if (thing.PricelistRef == "P1")
                        {
                            double res = calculatePriceChange(thing.Value ?? 0, true);
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef + " New Value: " + res);

                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P2";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);

                            var newPrice = new PriceType();
                            newPrice.Id = thing.Id;
                            newPrice.Code = thing.Code;
                            newPrice.PricelistRef = thing.PricelistRef;
                            newPrice.Value = res;

                            if (!alreadyModified.Contains(thing.Id))
                            {
                                results.Add((newPrice));
                            }
                        }
                        else if (thing.PricelistRef == "P2")
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P3";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);

                            //  context.PriceTypes.Update(oldPrice);
                            //  context.SaveChanges();

                        }
                        else if (thing.PricelistRef == "P3")
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P4";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);
                            //  context.PriceTypes.Update(oldPrice);
                            //  context.SaveChanges();

                        }
                        else if (thing.PricelistRef == "P4")
                        {
                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            var oldPrice = new PriceType();
                            oldPrice.Id = thing.Id + 1;
                            oldPrice.Code = thing.Code;
                            oldPrice.PricelistRef = "P5";
                            oldPrice.Value = thing.Value;

                            results.Add(oldPrice);
                            //  context.PriceTypes.Update(oldPrice);
                            //  context.SaveChanges();

                        }
                        else if (thing.PricelistRef == "P5")
                        {

                           

                            if (preview) Console.WriteLine("\t\tValue: " + thing.Value + "; " + thing.PricelistRef);
                            // context.PriceTypes.Remove(thing);
                            //  context.SaveChanges();
                            //do nothing
                        }
                    }
                }

                if (preview) Console.WriteLine("\t\nFINAL RESULTS: \n");
                foreach (var res in results)
                {

                    if (!alreadyModified.Contains(res.Id))
                    {
                        UpdatePriceType(context, res);
                        alreadyModified.Add(res.Id);
                    }
                    if (preview) Console.WriteLine("\t\tValue: " + res.Value + "; " + res.PricelistRef);

                }

                results.Clear();
                if (preview)Console.WriteLine("******************************************************");
            }
        }

            
        public double calculatePriceChange(double originalPrice, bool isProduct)
        {
                if (isProduct)
                {
                    if (productRoundDown)
                    {
                        return Math.Floor(originalPrice += originalPrice * productPriceChangeFactor);
                    } else
                    {
                    return Math.Ceiling(originalPrice += originalPrice * productPriceChangeFactor);
                     }
                } else
                {
                    if (optionRoundDown)
                    {
                        return Math.Floor(originalPrice += originalPrice * optionPriceChangeFactor);
                    }
                    else
                    {
                        return Math.Ceiling(originalPrice += originalPrice * optionPriceChangeFactor);
                    }

                }
            return originalPrice;
        }
        public bool UpdatePriceType(CetCatalogContext context, PriceType entity)
        {
            try
            {
                var entry = context.PriceTypes.First(e => e.Id == entity.Id);
                context.Entry(entry).CurrentValues.SetValues(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                // handle correct exception
                // log error
                return false;
            }
        }
    }
    }

