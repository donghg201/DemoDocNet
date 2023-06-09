using Demo.Dto;
using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Services;
using Demo.Uow;
using Demo.Uow.IUow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<MyDbContext>();


            services.AddScoped<IRepositoryInt<Branch>, BranchRepository>();
            services.AddScoped<IBranchUow, BranchUow>();
            services.AddScoped<BranchService>();

            services.AddScoped<ICustomerRepository<Customer>, CustomerRepository>();
            services.AddScoped<IBussinessRepository<Bussiness>, BussinessRepository>();
            services.AddScoped<IIndividualRepository<Individual>, IndividualRepository>();
            services.AddScoped<ICustomerUow, CustomerUow>();
            services.AddScoped<CustomerService>();

            services.AddScoped<IRepositoryInt<Department>, DepartmentRepository>();
            services.AddScoped<IDepartmentUow, DepartmentUow>();
            services.AddScoped<DepartmentService>();

            services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IEmployeeUow, EmployeeUow>();
            services.AddScoped<EmployeeService>();

            services.AddScoped<IRepositoryString<ProductType>, ProductTypeRepository>();
            services.AddScoped<IProductTypeUow, ProductTypeUow>();
            services.AddScoped<ProductTypeService>();

            services.AddScoped<IRepositoryString<Product>, ProductRepository>();
            services.AddScoped<IProductUow, ProductUow>();
            services.AddScoped<ProductService>();

            services.AddScoped<IRepositoryInt<Account>, AccountRepository>();
            services.AddScoped<IAccountUow, AccountUow>();
            services.AddScoped<AccountService>();

            services.AddScoped<IRepositoryInt<AccTransaction>, AccTransactionRepository>();
            services.AddScoped<IAccTransactionUow, AccTransactionUow>();
            services.AddScoped<AccTransactionService>();

            services.AddScoped<ITaskRepository<CustomerTaskDto>, TaskRepository>();
            services.AddScoped<ITaskUow, TaskUow>();
            services.AddScoped<TaskService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
