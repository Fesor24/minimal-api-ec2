var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Book> books = [
    new Book{Id = 1, Author = "George Martin", Title = "Game of Thrones"},
    new Book{Id = 2, Author = "Chinua Achebe", Title = "Things fall apart"}
    
    ];

app.MapGet("/api/books", () =>
{
    return books;
})
.WithName("GetBooks")
.WithOpenApi();

app.Run();

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
