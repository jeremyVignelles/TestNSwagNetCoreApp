// This is the class that uses HTTP

export class UseHttpCookiesForApi {
    protected transformOptions(options: RequestInit): Promise<RequestInit> {
        options.credentials = 'same-origin';
        return Promise.resolve(options);
    }
}