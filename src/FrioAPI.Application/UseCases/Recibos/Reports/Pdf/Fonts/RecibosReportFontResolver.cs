using PdfSharp.Fonts;
using System.Reflection;

namespace FrioAPI.Application.UseCases.Recibos.Reports.Pdf.Fonts
{
    public class RecibosReportFontResolver : IFontResolver
    {
        public byte[]? GetFont(string faceName)
        {
            var stream = ReadFontFile(faceName);
            //se stream for nulo ele coloca fonte default
            stream ??= ReadFontFile(FontHelper.DEFAULT_FONT);


            var length = (int)stream!.Length;
            var data = new byte[length];
            stream.Read(data, 0, length);

            return data;
        }

        public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            return new FontResolverInfo(familyName);
        }

        private Stream? ReadFontFile(string faceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream($"FrioAPI.Application.UseCases.Recibos.Reports.Pdf.Fonts.{faceName}.ttf");
        }
    }
}
