using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewWareAttributeGroupsQueryRequest : JdRequestBase<NewWareAttributeGroupsQueryResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                   		public  		string
  id {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.new.ware.AttributeGroups.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                            }
    }
}





        
 

