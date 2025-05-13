using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using BlogLib;

namespace BlogHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(BlogService));

            try
            {
                ((ServiceAuthorizationBehavior)host.Description.Behaviors[typeof(ServiceAuthorizationBehavior)]).PrincipalPermissionMode = PrincipalPermissionMode.None;

                host.Open();
                Console.WriteLine("BlogService is running...");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                host.Abort();
            }
        }
    }
}
