using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheGoodsGetRequest : JdRequestBase<KuaicheGoodsGetResponse>
    {
                                                                                                                   public  		string
                                                                                      skuId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.goods.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("sku_id", this.                                                                                    skuId
);
                                                    }
    }
}





        
 

