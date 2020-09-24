using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;
using Microsoft.AspNet.Identity;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace ApartmentManager.Controllers
{
    
    public class PrintController : Controller
    {
        private ApplicationDbContext _context;
        public PrintController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Print
        public ActionResult Index()
        {
            return View();
        }

        // GET: Print Invoice
        public ActionResult Invoice(int Id)
        {
            var invoice = _context.MaintenanceInvoice.SingleOrDefault(c => c.Id == Id);
            
            var apartment = _context.Apartment.SingleOrDefault(c => c.Id == invoice.ApartmentId);

            var owner = _context.Owner.SingleOrDefault(o => o.Id == apartment.OwnerId);

            if (invoice == null || apartment == null || owner == null)
                return HttpNotFound();


            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            // Invoice body
            RectangleF bounds = new RectangleF(176, 0, 390, 130);
            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            bounds = new RectangleF(0, bounds.Bottom + 90, graphics.ClientSize.Width, 30);
            //Draws a rectangle to place the heading in that region.
            graphics.DrawRectangle(solidBrush, bounds);
            //Creates a font for adding the heading in the page
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            //Creates a text element to add the invoice number
            PdfTextElement element = new PdfTextElement("INVOICE " + invoice.Id.ToString(), subHeadingFont);
            element.Brush = PdfBrushes.White;

            //Draws the heading on the page
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = "DATE " + DateTime.Now.ToString("MM/dd/yyyy");
            //Measures the width of the text to place it in the correct location
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            //Draws the date by using DrawString method
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
            //Creates text elements to add the address and draw it to the page.
            element = new PdfTextElement("BILL TO ", timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 25));
            PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
            PointF startPoint = new PointF(0, result.Bounds.Bottom + 3);
            PointF endPoint = new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 3);
            //Draws a line at the bottom of the address
            graphics.DrawLine(linePen, startPoint, endPoint);


            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            var pdfName = "invoice_"+apartment.FloorNo + "_" + apartment.UnitNo + "_" + invoice.MonthId + ".pdf";

            fileStreamResult.FileDownloadName = pdfName;

            return fileStreamResult;
        }
    }
}