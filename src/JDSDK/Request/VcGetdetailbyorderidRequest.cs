using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcGetdetailbyorderidRequest : JdRequestBase<VcGetdetailbyorderidResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
                                                                                      sortFiled
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      sortMode
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                          public  	    Nullable<bool>
                                                                                      isPage
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.vc.getdetailbyorderid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                                                                        parameters.Add("sort_filed", this.                                                                                    sortFiled
);
                                                                                                        parameters.Add("sort_mode", this.                                                                                    sortMode
);
                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                        parameters.Add("is_page", this.                                                                                    isPage
);
                                                                            }
    }
}





        
 

