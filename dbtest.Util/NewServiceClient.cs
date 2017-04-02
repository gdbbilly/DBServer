using dbtest.Util.ClientServiceReference;
using System;

namespace dbtest.Util
{
    public static class NewServiceClient
    {
        public static RestaurantServiceClient InstanceService()
        {

            RestaurantServiceClient service = new RestaurantServiceClient();

            try
            {
                if (service.Endpoint != null && service.Endpoint.Binding != null)
                {
                    service.Endpoint.Binding.CloseTimeout = new TimeSpan(1, 1, 1);
                    service.Endpoint.Binding.OpenTimeout = new TimeSpan(1, 1, 1);
                    service.Endpoint.Binding.SendTimeout = new TimeSpan(1, 1, 1);
                    service.Endpoint.Binding.ReceiveTimeout = new TimeSpan(1, 1, 1);
                }

                if (service.Endpoint.Binding is System.ServiceModel.BasicHttpBinding)
                {
                    System.ServiceModel.BasicHttpBinding basic = (System.ServiceModel.BasicHttpBinding)service.Endpoint.Binding;
                    if (basic != null)
                    {
                        basic.MaxBufferSize = 2147483647;
                        basic.MaxReceivedMessageSize = 2147483647;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return service;
        }
    }
}
