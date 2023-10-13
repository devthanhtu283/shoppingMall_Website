import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GallaryComponent } from "./components/gallary/gallary.component";
import { ProductComponent } from "./components/product/product.component";
import { Food_DrinkComponent } from "./components/food-drink/food_drink.component";
import { HomeComponent } from "./components/home/home.component";
import { ShoppingComponent } from "./components/shopping/shopping.component";
import { Enter_learnComponent } from "./components/enter_learn/enter_learn.component";
import { AboutComponent } from "./components/about/about.component";
import { NewsComponent } from "./components/news/news.component";
import { FeedbackComponent } from "./components/feedback/feedback.component";
import { HomeCinemaComponent } from "./components/Cinema home/homecinema.component";
import { DetailsCinemaComponent } from "./components/Cinema details/detailscinema.component";

const routes: Routes = [
  {
    path: "",
    component: HomeComponent,
  },
  {
    path: "home",
    component: HomeComponent,
  },
  {
    path: "product",
    component: ProductComponent,
  },
  {
    path: "food-drink",
    component: Food_DrinkComponent,
  },
  {
    path: "shopping",
    component: ShoppingComponent,
  },
  {
    path: "entertainment-learning",
    component: Enter_learnComponent,
  },
  {
    path: "about",
    component: AboutComponent,
  },
  {
    path: "gallery",
    component: GallaryComponent,
  },
  {
    path: "news",
    component: NewsComponent,
  },

  {
    path: "feedback",
    component: FeedbackComponent,
  },
  {
    path: "cinema",
    component: HomeCinemaComponent,
  },
  {
    path: "details-cinema/:showId",
    component: DetailsCinemaComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
