import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ToastModule } from "primeng/toast";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { GallaryComponent } from "./components/gallary/gallary.component";
import { ProductComponent } from "./components/product/product.component";
import { Food_DrinkComponent } from "./components/food-drink/food_drink.component";
import { HomeComponent } from "./components/home/home.component";
import { ShopAPIService } from "./services/shopAPI.service";
import { BaseUrlService } from "./services/baseUrl.service";
import { HttpClientModule } from "@angular/common/http";
import { ShoppingComponent } from "./components/shopping/shopping.component";
import { Enter_learnComponent } from "./components/enter_learn/enter_learn.component";
import { ProductAPIService } from "./services/productAPI.service";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DropdownModule } from "primeng/dropdown";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AboutComponent } from "./components/about/about.component";
import { NewsComponent } from "./components/news/news.component";
import { GallaryAPIService } from "./services/gallaryAPI.service";
import { EditorModule } from "primeng/editor";
import { RatingModule } from "primeng/rating";
import { ButtonModule } from "primeng/button";
import { FieldsetModule } from "primeng/fieldset";
import { InputTextModule } from "primeng/inputtext";
import { HomeCinemaComponent } from "./components/Cinema home/homecinema.component";
import { DetailsCinemaComponent } from "./components/Cinema details/detailscinema.component";
import { FeedbackAPIService } from "./services/feedbackapi.service";
import { FeedbackComponent } from "./components/feedback/feedback.component";
import { ConfirmationService, MessageService } from "primeng/api";
import { ShowAPIService } from "./services/showAPI.service";
import { TicketAPIService } from "./services/ticketAPI.service";
@NgModule({
  declarations: [
    AppComponent,
    GallaryComponent,
    ProductComponent,
    Food_DrinkComponent,
    HomeComponent,
    ShoppingComponent,
    Enter_learnComponent,
    ProductComponent,
    AboutComponent,
    NewsComponent,
    GallaryComponent,
    FeedbackComponent,
    HomeCinemaComponent,
    DetailsCinemaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    DropdownModule,
    EditorModule,
    RatingModule,
    ButtonModule,
    FieldsetModule,
    InputTextModule,
    RatingModule,
    ToastModule,
  ],
  providers: [
    ShopAPIService,
    BaseUrlService,
    ProductAPIService,
    GallaryAPIService,
    FeedbackAPIService,
    MessageService,
    ConfirmationService,
    ShowAPIService,
    TicketAPIService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
