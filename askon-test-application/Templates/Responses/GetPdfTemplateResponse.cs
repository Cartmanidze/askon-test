namespace askon_test_application.Templates.Responses;

/// <summary>
/// Ответ получения шаблона в pdf
/// </summary>
public record GetPdfTemplateResponse(string FileName, Stream Stream);