using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HairQueryBookRequest : JdRequestBase<HairQueryBookResponse>
    {
                                                                                                                                              public  		string
              beginDate
 {get; set;}
                                                          
                                                          public  		string
              supNo
 {get; set;}
                                                          
                                                          public  		string
              poNo
 {get; set;}
                                                          
                                                                                           public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              whNo
 {get; set;}
                                                          
                                                          public  		string
              ownerNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dcNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.hair.queryBook";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("supNo", this.            supNo
);
                                                                                                        parameters.Add("poNo", this.            poNo
);
                                                                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("whNo", this.            whNo
);
                                                                                                        parameters.Add("ownerNo", this.            ownerNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("dcNo", this.            dcNo
);
                                                                            }
    }
}





        
 

