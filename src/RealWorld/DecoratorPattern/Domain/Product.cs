﻿namespace DecoratorPattern.Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } =  string.Empty;

    public Product(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
