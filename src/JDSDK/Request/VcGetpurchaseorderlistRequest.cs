using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcGetpurchaseorderlistRequest : JdRequestBase<VcGetpurchaseorderlistResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
                                                                                                                      createdDateStart
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                      createdDateEnd
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                                                      deliverCenterId
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
                                                                                                                      isEptCustomized
 {get; set;}
                                                                                                                                                          
                                                                                           public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                                                      public  		string
              orderIds
 {get; set;}
                                                          
                                                                                      public  		string
              wareIds
 {get; set;}
                                                          
                                                                                      public  		string
              states
 {get; set;}
                                                          
                                                                                      public  		string
              confirmStates
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.vc.getpurchaseorderlist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("created_date_start", this.                                                                                                                    createdDateStart
);
                                                                                                        parameters.Add("created_date_end", this.                                                                                                                    createdDateEnd
);
                                                                                                        parameters.Add("deliver_center_id", this.                                                                                                                    deliverCenterId
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("is_ept_customized", this.                                                                                                                    isEptCustomized
);
                                                                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                        parameters.Add("orderIds", this.            orderIds
);
                                                                                                        parameters.Add("wareIds", this.            wareIds
);
                                                                                                        parameters.Add("states", this.            states
);
                                                                                                        parameters.Add("confirmStates", this.            confirmStates
);
                                                                            }
    }
}





        
 

