using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsSearchoutboundorderRequest : JdRequestBase<DropshipDpsSearchoutboundorderResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              beginDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dropship.dps.searchoutboundorder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                            }
    }
}





        
 

