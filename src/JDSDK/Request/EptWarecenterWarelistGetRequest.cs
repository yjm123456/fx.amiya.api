using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EptWarecenterWarelistGetRequest : JdRequestBase<EptWarecenterWarelistGetResponse>
    {
                                                                                                                                                                               public  		string
              wareIdsStr
 {get; set;}
                                                          
                                                          public  		string
              wareStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              categoryId
 {get; set;}
                                                          
                                                          public  		string
              title
 {get; set;}
                                                          
                                                          public  		string
              itemNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              transportId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startOnlineTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endOnlineTime
 {get; set;}
                                                          
                                                          public  		string
              minSupplyPrice
 {get; set;}
                                                          
                                                          public  		string
              maxSupplyPrice
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              recommendTpid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ept.warecenter.warelist.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("wareIdsStr", this.            wareIdsStr
);
                                                                                                        parameters.Add("wareStatus", this.            wareStatus
);
                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                        parameters.Add("title", this.            title
);
                                                                                                        parameters.Add("itemNum", this.            itemNum
);
                                                                                                        parameters.Add("transportId", this.            transportId
);
                                                                                                        parameters.Add("startOnlineTime", this.            startOnlineTime
);
                                                                                                        parameters.Add("endOnlineTime", this.            endOnlineTime
);
                                                                                                        parameters.Add("minSupplyPrice", this.            minSupplyPrice
);
                                                                                                        parameters.Add("maxSupplyPrice", this.            maxSupplyPrice
);
                                                                                                        parameters.Add("recommendTpid", this.            recommendTpid
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                            }
    }
}





        
 

