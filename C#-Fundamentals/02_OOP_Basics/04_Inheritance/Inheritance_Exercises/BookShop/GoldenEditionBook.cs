class GoldenEditionBook:Book
{
    protected override decimal Price
    {
        get
        {
            return base.Price * (decimal)1.3;
        }
    }


    public GoldenEditionBook(string name, string title, decimal price)
        :base(name,title,price)
    {
        
    }
}
