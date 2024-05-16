Console.WriteLine("Hello, Liskov Substitution Principle (LSP)!");

Document doc1 = new PDFDocument();
Document doc2 = new TextDocument();

doc1.Print(); // Output: "Printing a PDF document..."

doc2.Edit(); 


public class Document
{
    public virtual void Print()
    {
        Console.WriteLine("Printing a document...");
    }

    public virtual void Edit()
    {
        Console.WriteLine("Editing a document...");
    }

    public virtual bool CanEdit()
    {
        return false; // By default, documents are not editable
    }
}

public class PDFDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing a PDF document...");
    }

    public void Encrypt()
    {
        Console.WriteLine("Encrypting a PDF document...");
    }

    public override void Edit()
    {
        throw new NotSupportedException();
    }
}

public class TextDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing a text document...");
    }

    public override void Edit()
    {
        Console.WriteLine("Editing a document...");
    }

    public override bool CanEdit()
    {
        return true; // Text documents are editable
    }
}

