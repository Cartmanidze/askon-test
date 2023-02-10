namespace askon_test_application.Templates.Responses;

/// <summary>
/// Ответ получения шаблона в doc
/// </summary>
public record GetDocTemplateResponse(string FileName, Stream Stream);