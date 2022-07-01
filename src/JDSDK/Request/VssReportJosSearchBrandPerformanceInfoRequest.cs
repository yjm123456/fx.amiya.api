using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VssReportJosSearchBrandPerformanceInfoRequest : JdRequestBase<VssReportJosSearchBrandPerformanceInfoResponse>
    {
                                                                                                                                                    public  		Nullable<int>
              searchType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              year
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              month
 {get; set;}
                                                          
                                                          public  		string
              daysCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.vss.report.jos.searchBrandPerformanceInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("searchType", this.            searchType
);
                                                                                                        parameters.Add("year", this.            year
);
                                                                                                        parameters.Add("month", this.            month
);
                                                                                                        parameters.Add("daysCode", this.            daysCode
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                    }
    }
}





        
 

