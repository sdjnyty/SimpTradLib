using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace YTY.SimpTradLib.Test
{
  [TestClass]
  public class SimpTradLibTest
  {
    [TestMethod]
    public void TestHasTraditionalFormAny()
    {
      Assert.IsFalse(SimpTradLib.HasTraditionalFormAny("你好"));
      Assert.IsTrue(SimpTradLib.HasTraditionalFormAny("简体"));
    }

    [TestMethod]
    public void TestHasTraditionalFormFirst()
    {
      Assert.IsTrue(SimpTradLib.HasTraditionalFormFirst("体"));
      Assert.IsFalse(SimpTradLib.HasTraditionalFormFirst("身体"));
    }

    [TestMethod]
    public void TestHasMultipleTraditionalFormsFirst()
    {
      Assert.IsTrue(SimpTradLib.HasMultipleTraditionalFormsFirst("余"));
      Assert.IsFalse(SimpTradLib.HasMultipleTraditionalFormsFirst("剩余"));
      Assert.IsFalse(SimpTradLib.HasMultipleTraditionalFormsFirst("体"));
    }

    [TestMethod]
    public void TestGetTraditionalFormFirst()
    {
      Assert.AreEqual("體", SimpTradLib.GetTraditionalFormFirst("体"));
      Assert.ThrowsException<ArgumentOutOfRangeException>(() => SimpTradLib.GetTraditionalFormFirst("你好"));
    }

    [TestMethod]
    public void TestGetTraditionalFormsFirst()
    {
      CollectionAssert.AreEquivalent(new[] {"體"}, SimpTradLib.GetTraditionalFormsFirst("体"));
      CollectionAssert.AreEquivalent(new string[] { }, SimpTradLib.GetTraditionalFormsFirst("你好"));
      CollectionAssert.AreEquivalent(new[] {"乾", "幹"}, SimpTradLib.GetTraditionalFormsFirst("干"));
    }

    [TestMethod]
    public void TestConvertToTraditionalForm()
    {
      Assert.AreEqual("儘臟須一二", SimpTradLib.ConvertToTraditionalForm("尽脏须一二"));
      Assert.AreEqual("盡髒鬚一二", SimpTradLib.ConvertToTraditionalForm("尽脏须一二", coll => coll.Last()));
    }

    [TestMethod]
    public void TestHasSimplifiedFormFirst()
    {
      Assert.IsTrue(SimpTradLib.HasSimplifiedFormFirst( "體"));
      Assert.IsFalse(SimpTradLib.HasSimplifiedFormFirst("身體"));
    }

    [TestMethod]
    public void TestHasSimplifiedFormAny()
    {
      Assert.IsTrue(SimpTradLib.HasSimplifiedFormAny("身體"));
      Assert.IsFalse(SimpTradLib.HasSimplifiedFormAny("你好"));
    }

    [TestMethod]
    public void TestHasMultipleSimplifiedFormsFirst()
    {
      Assert.IsTrue(SimpTradLib.HasMultipleSimplifiedFormsFirst("鍾"));
      Assert.IsFalse(SimpTradLib.HasMultipleSimplifiedFormsFirst("體"));
    }

    [TestMethod]
    public void TestGetSimplifiedFormFirst()
    {
      Assert.AreEqual("体", SimpTradLib.GetSimplifiedFormFirst("體"));
      Assert.ThrowsException<ArgumentOutOfRangeException>(()=>SimpTradLib.GetSimplifiedFormFirst("好"));
    }

    [TestMethod]
    public void TestGetSimplifiedFormsFirst()
    {
      CollectionAssert.AreEquivalent(new[] {"体"}, SimpTradLib.GetSimplifiedFormsFirst("體"));
      CollectionAssert.AreEquivalent(new string[] { }, SimpTradLib.GetSimplifiedFormsFirst("好"));
      CollectionAssert.AreEquivalent(new[] {"余", "馀"}, SimpTradLib.GetSimplifiedFormsFirst("餘"));
    }

    [TestMethod]
    public void TestConvertToSimplifiedForm()
    {
      Assert.AreEqual("钟愿余一二", SimpTradLib.ConvertToSimplifiedForm("鍾願餘一二"));
      Assert.AreEqual("锺𫖸馀一二", SimpTradLib.ConvertToSimplifiedForm("鍾願餘一二", coll => coll.Last()));
    }
  }
}
