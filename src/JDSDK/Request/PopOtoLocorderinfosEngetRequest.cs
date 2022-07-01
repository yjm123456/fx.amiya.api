using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOtoLocorderinfosEngetRequest : JdRequestBase<PopOtoLocorderinfosEngetResponse>
    {
                                                                                                                   public  		Nullable<int>
                                                                                      timeType
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      startDate
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      endDate
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      codeStatus
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      codeType
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.pop.oto.locorderinfos.enget";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("time_type", this.                                                                                    timeType
);
                                                                                                        parameters.Add("start_date", this.                                                                                    startDate
);
                                                                                                        parameters.Add("end_date", this.                                                                                    endDate
);
                                                                                                        parameters.Add("code_status", this.                                                                                    codeStatus
);
                                                                                                        parameters.Add("code_type", this.                                                                                    codeType
);
                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                    }
    }
}





        
 

