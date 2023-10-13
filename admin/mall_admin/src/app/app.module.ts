import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ConfirmationService, MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DropdownModule } from 'primeng/dropdown';
import { FileUploadModule } from 'primeng/fileupload';
import { GalleriaModule } from 'primeng/galleria';
import { RatingModule } from 'primeng/rating';
import { ImageModule } from 'primeng/image';
import { CalendarModule } from 'primeng/calendar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/Login/login.component';
import { DashboardComponent } from './components/Dashboard/dashboard.component';
import { AdminComponent } from './components/Admin/admin.component';
import { AddStoreComponent } from './components/Store add-store/addstore.component';
import { BaseUrlService } from './services/baseurl.service';
import { AccountAPIService } from './services/accountapi.service';
import { StoreListingComponent } from './components/Store store-listing/storelisting.component';
import { StoreAPIService } from './services/storeapi.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditStoreComponent } from './components/Store edit-store/editstore.component';
import { StoreDetailsComponent } from './components/Store store-detail/storedetail.component';
import { CategoryAPIService } from './services/categoryapi.service';
import { ProductListingComponent } from './components/Product product-listing/product-listing.component';
import { ProductAPIService } from './services/productapi.service';
import { AddProductComponent } from './components/Product add-product/add-product.component';
import { ProductDetailComponent } from './components/Product product-detail/productdetail.component';
import { EditProductComponent } from './components/Product edit-product/editproduct.component';
import { AddGalleryComponent } from './components/Gallery add-gallery/addgallery.component';
import { GalleryListingComponent } from './components/Gallery gallery-listing/gallerylisting.component';
import { GalleryAPIService } from './services/galleryapi.service';
import { EditGalleryComponent } from './components/Gallery edit-gallery/editgallery.component';
import { FeedbackAPIService } from './services/feedbackapi.service';
import { FeedBackListingComponent } from './components/Feedback feedback-listing/feedbacklisting.component';
import { MovieAPIService } from './services/movieapi.service';
import { MovieListingComponent } from './components/Movie movie-listing/movie-listing.component';
import { AddMovieComponent } from './components/Movie add-movie/add-movie.component';
import { EditMovieComponent } from './components/Movie edit-movie/editmovie.component';
import { RoomListingComponent } from './components/Movie room-listing/room-listing.component';
import { RoomAPIService } from './services/roomapi.service';
import { ShowListingComponent } from './components/Movie show-listing/show-listing.component';
import { ShowAPIService } from './services/showapi.service';
import { TimeSlotListingComponent } from './components/Movie timeSlot-listing/timeSlot-listing.component';
import { TimeSlotAPIService } from './services/timeslotapi.service';
import { TicketAPIService } from './services/ticketapi.service';
import { TicketListingComponent } from './components/Movie ticket-listing/ticket-listing.component';
import { AddRoomComponent } from './components/Movie add-room/add-room.component';
import { AddShowComponent } from './components/Movie add-show/add-show.component';
import { AddTicketComponent } from './components/Movie add-ticket/add-ticket.component';
import { AddTimeSlotComponent } from './components/Movie add-timeSlot/add-timeSlot.component';
import { EditTimeSlotComponent } from './components/Movie edit-timeSlot/edit-timeSlot.component';

import { checkLoginService } from './services/checkLogin.service';

import { InputSwitchModule } from 'primeng/inputswitch';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    AdminComponent,
    AddStoreComponent,
    StoreListingComponent,
    EditStoreComponent,
    StoreDetailsComponent,
    ProductListingComponent,
    AddProductComponent,
    ProductDetailComponent,
    EditProductComponent,
    AddGalleryComponent,
    GalleryListingComponent,
    EditGalleryComponent,
    FeedBackListingComponent,
    MovieListingComponent,
    AddMovieComponent,
    EditMovieComponent,
    RoomListingComponent,
    ShowListingComponent,
    TimeSlotListingComponent,
    TicketListingComponent,
    AddRoomComponent,
    AddShowComponent,
    AddTicketComponent,
    AddTimeSlotComponent,
    EditTimeSlotComponent,
 
  ],
  
  imports: [
    BrowserModule,
    AppRoutingModule,
    ToastModule,
    ConfirmDialogModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ButtonModule,
    TableModule,
    InputTextModule,
    InputTextareaModule,
    DropdownModule,
    FileUploadModule,
    GalleriaModule,
    RatingModule,
    ImageModule,
    CalendarModule,
    InputSwitchModule
  ],

  providers: [
    BaseUrlService,
    AccountAPIService,
    MessageService,
    ConfirmationService,
    BaseUrlService,
    StoreAPIService,
    CategoryAPIService,
    ProductAPIService,
    GalleryAPIService,
    FeedbackAPIService,
    MovieAPIService,
    RoomAPIService,
    ShowAPIService,
    TimeSlotAPIService,
    TicketAPIService,
    checkLoginService
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
