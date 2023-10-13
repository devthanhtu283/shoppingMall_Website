import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/Login/login.component';
import { DashboardComponent } from './components/Dashboard/dashboard.component';
import { AdminComponent } from './components/Admin/admin.component';
import { AddStoreComponent } from './components/Store add-store/addstore.component';
import { StoreListingComponent } from './components/Store store-listing/storelisting.component';
import { EditStoreComponent } from './components/Store edit-store/editstore.component';
import { StoreDetailsComponent } from './components/Store store-detail/storedetail.component';
import { ProductListingComponent } from './components/Product product-listing/product-listing.component';
import { AddProductComponent } from './components/Product add-product/add-product.component';
import { ProductDetailComponent } from './components/Product product-detail/productdetail.component';
import { EditProductComponent } from './components/Product edit-product/editproduct.component';
import { GalleryListingComponent } from './components/Gallery gallery-listing/gallerylisting.component';
import { AddGalleryComponent } from './components/Gallery add-gallery/addgallery.component';
import { EditGalleryComponent } from './components/Gallery edit-gallery/editgallery.component';
import { FeedBackListingComponent } from './components/Feedback feedback-listing/feedbacklisting.component';
import { FeedbackDetailComponent } from './components/Feedback feedback-detail/feedbackdetail.component';
import { MovieListingComponent } from './components/Movie movie-listing/movie-listing.component';
import { AddMovieComponent } from './components/Movie add-movie/add-movie.component';
import { EditMovieComponent } from './components/Movie edit-movie/editmovie.component';
import { RoomListingComponent } from './components/Movie room-listing/room-listing.component';
import { ShowListingComponent } from './components/Movie show-listing/show-listing.component';
import { TimeSlotListingComponent } from './components/Movie timeSlot-listing/timeSlot-listing.component';
import { TicketListingComponent } from './components/Movie ticket-listing/ticket-listing.component';
import { AddRoomComponent } from './components/Movie add-room/add-room.component';
import { AddShowComponent } from './components/Movie add-show/add-show.component';
import { AddTicketComponent } from './components/Movie add-ticket/add-ticket.component';
import { AddTimeSlotComponent } from './components/Movie add-timeSlot/add-timeSlot.component';
import { EditTimeSlotComponent } from './components/Movie edit-timeSlot/edit-timeSlot.component';
import { ForbiddenComponent } from './components/Forbidden/forbidden.component';
import { checkLoginService } from './services/checkLogin.service';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'forbidden', component: ForbiddenComponent
  },
  {
    path: 'admin', component: AdminComponent, canActivate: [checkLoginService],
    children: [
      { path: 'dashboard', component: DashboardComponent },

      { path: 'store-listing', component: StoreListingComponent },
      { path: 'add-store', component: AddStoreComponent },
      { path: 'edit-store', component: EditStoreComponent },
      { path: 'store-detail', component: StoreDetailsComponent },

      { path: 'product-listing', component: ProductListingComponent },
      { path: 'add-product', component: AddProductComponent },
      { path: 'edit-product', component: EditProductComponent },
      { path: 'product-detail', component: ProductDetailComponent },

      { path: 'gallery-listing', component: GalleryListingComponent },
      { path: 'add-gallery', component: AddGalleryComponent },
      { path: 'edit-gallery', component: EditGalleryComponent },

      { path: 'feedback-listing', component: FeedBackListingComponent },
      { path: 'feedback-detail', component: FeedbackDetailComponent },

      { path: 'movie-listing', component: MovieListingComponent },
      { path: 'add-movie', component: AddMovieComponent },
      { path: 'edit-movie', component: EditMovieComponent },

      { path: 'room-listing', component: RoomListingComponent },
      { path: 'add-room', component: AddRoomComponent },

      { path: 'show-listing', component: ShowListingComponent },
      { path: 'add-show', component: AddShowComponent },

      { path: 'timeSlot-listing', component: TimeSlotListingComponent },
      { path: 'add-timeSlot', component: AddTimeSlotComponent },
      { path: 'edit-timeSlot', component: EditTimeSlotComponent },

      { path: 'ticket-listing', component: TicketListingComponent },
      { path: 'add-ticket', component: AddTicketComponent },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
