import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../user/service/account.services';
import { Observable, tap } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router, private accountService: AccountService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      const currentUser = this.accountService.getCurrentUser();

      if (currentUser && currentUser.token){
        if(req.body instanceof FormData){
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser.token}`
                }
            })
        }
      }

      return next.handle(req).pipe(
        tap(
            () => {},
            (err: any) => {
                if (err instanceof HttpErrorResponse){
                    if (err.status == 401){
                        this.router.navigate(['/login']);
                    }
                }
            }
        )
      )
  }
}
