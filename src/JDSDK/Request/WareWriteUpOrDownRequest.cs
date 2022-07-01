using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareWriteUpOrDownRequest : JdRequestBase<WareWriteUpOrDownResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                          public  		string
              note
 {get; set;}
                                                          
                                                                                                                                                             public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              opType
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ware.write.upOrDown";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                                                parameters.Add("note", this.            note
);
                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                parameters.Add("opType", this.            opType
);
                                                    }
    }
}





        
 

