using Autofac;
using CMSSimple.BusinessLogic;
using CMSSimple.StorageServices;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMSSimple.IoC.Config
{
    public class CommonModule : Module
    {
        public CommonModule(string connectionString) 
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleService>()
                .As<IArticleService>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<AddArticleRequestHandler>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<UpdateArticleRequestHandler>()
                .AsSelf()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<DeleteArticleRequestHandler>()
                .AsSelf()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<GetArticleRequestHandler>()
                .AsSelf()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<GetListArticlesRequestHandler>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
