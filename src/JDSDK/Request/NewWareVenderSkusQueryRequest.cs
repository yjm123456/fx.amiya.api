using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewWareVenderSkusQueryRequest : JdRequestBase<NewWareVenderSkusQueryResponse>
    {
                                                                                                                   public  		string
              index
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.new.ware.vender.skus.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("index", this.            index
);
                                                    }
    }
}





        
 

