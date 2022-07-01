using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CreateEntityStoresGroupRequest : JdRequestBase<CreateEntityStoresGroupResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                                                           public  		string
              name
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  storeId {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.createEntityStoresGroup";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                                                                parameters.Add("storeId", this.            storeId
);
                                                                                                    }
    }
}





        
 

