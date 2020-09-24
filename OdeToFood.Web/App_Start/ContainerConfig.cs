using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


// namespace generally maps to folder structure
namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            // Autofac API
            // tell container different containers to resolve dependencies (generic design pattern)
            var builder = new ContainerBuilder();

            // tell builder the abstractions in this application

            // MvcApplication comes from Global.asax.cs meaning *this* application
            builder.RegisterControllers(typeof(MvcApplication).Assembly); // scan through application and register controllers with autofac
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly); // register the api controllrs specifically 


            //builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance(); 
            // register ImemoryRestaurantData as a type whenver irestauratdata is requested 

            builder.RegisterType<SqlRestaurantData>().As<IRestaurantData>().InstancePerRequest(); // look in the database instead and create an instance of the SQLData everytime a http request is made rather than singleton that gets used once and it is gone
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            // reuse to register container for mvc and webapi frameworks

            // constructing a container by registereing all inmemoryrestaurant data and telling the framework to set container as dependency resolver
            var container = builder.Build();
            //whenever resolve dependency, use container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // static method
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);// use nstance of httpconfiguration
        }
    }
}