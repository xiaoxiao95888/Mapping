using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping.Model;

namespace Mapping.Helper
{
    public static class MatchedHelper
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Matched(Item item)
        {
            var matched = new Matched
            {
                Item = item,
                //MatchedInstitutionModels = new List<MatchedInstitutionModel>()
            };
            DataSource.Matcheds.Add(matched);
            var nameMatched =
                DataSource.InstitutionModels.FirstOrDefault(
                    n =>
                        n.Name.Trim() == item.Name ||
                        (n.UsedNames != null && n.UsedNames.Any(p => p != null && p.Trim() == item.Name)));
            if (nameMatched != null)
            {
                matched.MatchedInstitutionModel = new MatchedInstitutionModel
                {
                    Id = nameMatched.Id,
                    Name = nameMatched.Name,
                    Type = nameMatched.Type,
                    TypeCode = nameMatched.TypeCode,
                    Address = nameMatched.Address,
                    LocationCode = nameMatched.LocationCode,
                    LocationName = nameMatched.LocationName,
                    Words = nameMatched.Words,
                    UpdateTime = nameMatched.UpdateTime,
                    Percent = 1,
                    Code = nameMatched.Code
                };
            }
            else
            {
                if (item.JoinWords != null)
                {
                    //根据分词来过滤
                    var filter = DataSource.InstitutionModels.Where(n => item.JoinWords.Count(x => n.Name.Contains(x)) > 0);
                    //根据地理来过滤

                    if (item.Places.Any())
                    {
                        filter =
                            filter.Where(
                                n =>
                                    item.Places.Any(
                                        p =>
                                            p.Province == n.Province && p.City == n.City));
                    }
                    else
                    {
                        filter = filter.Where(n =>
                            (n.Province == item.Province || string.IsNullOrEmpty(item.Province)) &&
                            (n.City == item.City || string.IsNullOrEmpty(item.City))
                            //&& (n.District == item.District || string.IsNullOrEmpty(item.District))
                            );
                    }
                    //分析权重
                    var result = new List<MatchedInstitutionModel>();
                    foreach (var ins in filter)
                    {
                        var percent = (decimal)1;
                        if (ins.Province != item.Province)
                        {
                            percent = percent - (decimal)0.18;
                            if (item.Places.Any(n => n.Province == ins.Province))
                            {
                                percent = percent + (decimal)(0.18 * 0.8);
                            }
                        }
                        if (ins.City != item.City)
                        {
                            percent = percent - (decimal)0.12;
                            if (item.Places.Any(n => n.City == ins.City))
                            {
                                percent = percent + (decimal)(0.12 * 0.8);
                            }
                        }
                        //if (ins.District != item.District)
                        //{
                        //    percent = percent - (decimal)0.18;
                        //    if (item.Places.Any(n => n.District == ins.District))
                        //    {
                        //        percent = percent + (decimal)(0.18 * 0.8);
                        //    }
                        //}
                        percent = percent - (decimal)0.6;
                        if (ins.JoinWords != null && item.JoinWords != null)
                        {
                            var leftproportion = (decimal)ins.JoinWords.Distinct().Count(n => item.JoinWords.Distinct().Any(p => p == n)) / ins.JoinWords.Distinct().Count();
                            var rightproportion = (decimal)item.JoinWords.Distinct().Count(n => ins.JoinWords.Distinct().Any(p => p == n)) / item.JoinWords.Distinct().Count();
                            var participlesWeight = (leftproportion + rightproportion) / 2 * (decimal)0.6;
                            percent = percent + participlesWeight;
                            //行业的权重
                            percent = percent - (decimal)0.1;
                            if (string.IsNullOrEmpty(item.TypeCode) == false &&
                                string.IsNullOrEmpty(ins.TypeCode) == false && ins.TypeCode == item.TypeCode)
                            {
                                percent = percent + (decimal)0.1;
                            }
                        }

                        result.Add(new MatchedInstitutionModel
                        {
                            Id = ins.Id,
                            Name = ins.Name,
                            Type = ins.Type,
                            TypeCode = ins.TypeCode,
                            Address = ins.Address,
                            LocationCode = ins.LocationCode,
                            LocationName = ins.LocationName,
                            Words = ins.Words,
                            UpdateTime = ins.UpdateTime,
                            Percent = percent,
                            Code = ins.Code
                        });
                    }
                    //matched.MatchedInstitutionModels = result.OrderByDescending(n => n.Percent).ToList();
                    matched.MatchedInstitutionModel = result.OrderByDescending(n => n.Percent).FirstOrDefault();
                }

            }

        }
    }
}
