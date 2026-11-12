import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

// Solo deja entrar si existe el token guardado en el login
export const authGuard: CanActivateFn = () => {
    const router = inject(Router);

    if (localStorage.getItem('token')) {
        return true;
    }
    return router.createUrlTree(['/login']);
};
