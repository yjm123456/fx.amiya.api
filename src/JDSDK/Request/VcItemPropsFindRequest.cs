using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemPropsFindRequest : JdRequestBase<VcItemPropsFindResponse>
    {
                                                                                                                   public  		string
                                                                                                                      categoryLeafId
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.vc.item.props.find";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("category_leaf_id", this.                                                                                                                    categoryLeafId
);
                                                    }
    }
}





        
 

