import { Component} from "@angular/core";
import { Hero } from "../hero";
//import { HEROES } from "../mock-heroes";
import { HeroService } from '../hero.service';
import { MessageService } from "../message.service";


@Component({
  selector: 'app-heroes',
  templateUrl: 'heroes.component.html',
  styleUrls: ['heroes.component.css']
})
export class HeroesComponent{
  /*hero: Hero ={
    id: 1,
    name: 'Windstorm'
  };*/
  //heroes = HEROES;
  heroes:  Hero[] = [];
  //selectedHero?: Hero;
  constructor(private heroService: HeroService) {} //,  private messageService: MessageService
  ngOnInit(): void {
    this.getHeroes();
  }
  getHeroes(): void {
    //this.heroes = this.heroService.getHeroes();
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes);

  }
  /*onSelect(hero: Hero) {
    this.selectedHero = hero;
    this.messageService.add(`HeroesComponent: Selected hero id=${hero.id}`);
  }*/

  add(name: string) {
    name = name.trim();
    if (!name) { return; }
    this.heroService.addHero({ name } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

  delete(hero: Hero) {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero.id)
      .subscribe();
  }
}
