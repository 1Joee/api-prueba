import { HttpInterceptorFn } from '@angular/common/http';

// Agrega el token JWT guardado en el login a cada petición
export const authInterceptor: HttpInterceptorFn = (req, next) => {
    const token = localStorage.getItem('token');

    if (!token) {
        return next(req);
    }

    const authReq = req.clone({
        setHeaders: { Authorization: `Bearer ${token}` }
    });
    return next(authReq);
};
