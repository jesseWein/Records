using System;
using System.IO;
using System.Linq;
using Records.Model.Services;
using Xunit;

namespace Records.Test;

public class TestParse
{
    private string testData = "User | John | juser@something.com | Red | 1/12/1985";

    private Stream getStream(string data)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(data);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
    
    [Fact]
    public void Parser_ParsePersons_Pipe_Pass()
    {
        var result = Parser.ParsePersons(getStream(testData), "pipe");
        Assert.True(result.Count() == 1);
    }
[Fact]
    public void Parser_ParsePersons_Pipe_IndexOutOfRange()
    {
        var testData1 = testData.Remove(5, 2);
        var ex = Assert.Throws<IndexOutOfRangeException>(()=>Parser.ParsePersons(getStream(testData1), "pipe"));
    }
}